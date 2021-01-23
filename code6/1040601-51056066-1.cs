    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Xml;
    
    using NUnit.Framework;
    
    namespace Base.Test.Unit
    {
        [TestFixture]
        public class NugetTest
        {
            private const string PACKAGES_CONFIG_FILE_NAME = "packages.config";
            private const string BACKEND_DIRECTORY_NAME = "DeviceCloud/";
            private const string PACKAGES_NODE_NAME = "packages";
            private const string PACKAGE_ID_ATTRIBUTE_NAME = "id";
            private const string PACKAGE_VERSION_ATTRIBUTE_NAME = "version";
            /// <summary>
            /// Tests that all referenced nuget packages have the same version by doing:
            /// - Get all packages.config files contained in the backend
            /// - Retrieve the id and version of all packages
            /// - Fail this test if any referenced package has referenced to more than one version accross projects
            /// - Output a message mentioning the different versions for each package 
            /// </summary>
            [Test]
            public void EnforceCoherentReferences()
            {
                // Act
                IDictionary<string, ICollection<PackageVersionItem>> packageVersionsById = new Dictionary<string, ICollection<PackageVersionItem>>();
                foreach (string packagesConfigFilePath in GetAllPackagesConfigFilePaths())
                {
                    var doc = new XmlDocument();
                    doc.Load(packagesConfigFilePath);
                    XmlNode packagesNode = doc.SelectSingleNode(PACKAGES_NODE_NAME);
                    if (packagesNode != null && packagesNode.HasChildNodes)
                    {
                        foreach (var packageNode in packagesNode.ChildNodes.Cast<XmlNode>())
                        {
                            if (packageNode.Attributes == null)
                            {
                                continue;
                            }
                            string packageId = packageNode.Attributes[PACKAGE_ID_ATTRIBUTE_NAME].Value;
                            string packageVersion = packageNode.Attributes[PACKAGE_VERSION_ATTRIBUTE_NAME].Value;
                            if (!packageVersionsById.TryGetValue(packageId, out ICollection<PackageVersionItem> packageVersions))
                            {
                                packageVersions = new List<PackageVersionItem>();
                                packageVersionsById.Add(packageId, packageVersions);
                            }
                            //if (!packageVersions.Contains(packageVersion))
                            if(!packageVersions.Any(o=>o.Version.Equals(packageVersion)))
                            {
                                packageVersions.Add(new PackageVersionItem()
                                {
                                    SourceFile = packagesConfigFilePath,
                                    Version = packageVersion
                                });
                            }
                            if (packageVersions.Count > 1)
                            {
                                //breakpoint to examine package source
                            }
                        }
                    }
                }
                List<KeyValuePair<string, ICollection<PackageVersionItem>>> packagesWithIncoherentVersions = packageVersionsById.Where(kv => kv.Value.Count > 1).ToList();
                // Assert
                string errorMessage = string.Empty;
                if (packagesWithIncoherentVersions.Any())
                {
                    errorMessage = $"Some referenced packages have incoherent versions. Please fix them by adapting the nuget reference:{Environment.NewLine}";
                    foreach (var packagesWithIncoherentVersion in packagesWithIncoherentVersions)
                    {
                        string packageName = packagesWithIncoherentVersion.Key;
                        string packageVersions = string.Join("\n  ", packagesWithIncoherentVersion.Value);
                        errorMessage += $"{packageName}:\n  {packageVersions}\n\n";
                    }
                }
                Assert.IsTrue(packagesWithIncoherentVersions.Count == 0,errorMessage);
                //Assert.IsEmpty(packagesWithIncoherentVersions, errorMessage);
            }
            private static IEnumerable<string> GetAllPackagesConfigFilePaths()
            {
                return Directory.GetFiles(GetBackendDirectoryPath(), PACKAGES_CONFIG_FILE_NAME, SearchOption.AllDirectories)
                    .Where(o=>!o.Contains(".nuget"));
            }
            private static string GetBackendDirectoryPath()
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path.Substring(0, path.IndexOf(BACKEND_DIRECTORY_NAME, StringComparison.Ordinal) + BACKEND_DIRECTORY_NAME.Length));
            }
        }
        public class PackageVersionItem
        {
            public string SourceFile { get; set; }
            public string Version { get; set; }
            public override string ToString()
            {
                return $"{Version} in {SourceFile}";
            }
        }
    }
