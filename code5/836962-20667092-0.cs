    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using System.IO;
    
    public class FilesUtilityTests {
        [Test]
        public void TidyUpXmlFilesDeletesXmlFilesWhenNotDebugging() {
            string testFilePath = TestFileHelper.UseTestMasterFile("YourXmlFile.xml");
            FilesUtility util = new FilesUtility();
            
            util.TidyUpXmlFiles(false, TestFileHelper.TestDirectoryName);
            
            Assert.IsFalse(File.Exists(testFilePath));
            // any other tests here.
        }
    }
    
    // Obviously, this could be in a separate dll that you reference on all test projects.
    public static class TestFileHelper {
        public const string TestFolderName = @"Testing\UnitTests";
        public const string DefaultMasterFilesFolderName = "MasterFiles";
        public static string DefaultTestDirectoryName {
            get { return Path.Combine(Path.GetDirectoryName(System.Environment.CurrentDirectory), TestFolderName); }
        }
        public static string TestDirectoryName {
            get { return testDirectoryName ?? DefaultTestDirectoryName; }
            set { testDirectoryName = value; }
        }
        private static string testDirectoryName;
        public static string MasterFilesFolderName {
            get { return masterFilesFolderName ?? DefaultMasterFilesFolderName; }
            set { masterFilesFolderName = value; }
        }
        private static string masterFilesFolderName;
        public static string TestFileExtension { get; set; }
        public static string BuildTestFileName(string fileName) {
            if (String.IsNullOrWhiteSpace(Path.GetPathRoot(fileName)))
                fileName = Path.Combine(TestDirectoryName, fileName);
            if (String.IsNullOrEmpty(Path.GetExtension(fileName)))
                fileName = Path.ChangeExtension(fileName, TestFileExtension);
            return fileName;
        }
        public static string BuildTestMasterFileName(string fileName) {
            if (Path.IsPathRooted(fileName))
                return Path.Combine(Path.Combine(Path.GetDirectoryName(fileName), MasterFilesFolderName), Path.GetFileName(fileName));
            else
                return Path.Combine(Path.Combine(TestDirectoryName, MasterFilesFolderName), fileName);
        }
        public static string UseTestMasterFile(string fileName) {
            string dest = BuildTestFileName(fileName);
            string source = BuildTestMasterFileName(dest);
            DeleteTestFile(dest);
            ClearReadOnlyAttributes(source);
            File.Copy(source, dest, true);
            return dest;
        }
        
        public static void DeleteTestFile(string filePath) {
            if (String.IsNullOrWhiteSpace(filePath)) { return; }
            if (!File.Exists(filePath)) { return; }
            
            ClearReadOnlyAttributes(filePath);
            File.Delete(filePath);
        }
        
        public static void ClearReadOnlyAttributes(string filePath) {
            if (String.IsNullOrWhiteSpace(filePath)) { return; }
            if (!File.Exists(filePath)) { return; }
            FileAttributes attributes = File.GetAttributes(filePath);
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes(filePath, attributes ^ FileAttributes.ReadOnly);
        }
        public static void SetReadOnlyAttributes(string filePath) {
            if (String.IsNullOrWhiteSpace(filePath)) { return; }
            if (!File.Exists(filePath)) { return; }
            FileAttributes attributes = File.GetAttributes(filePath);
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                File.SetAttributes(filePath, attributes | FileAttributes.ReadOnly);
        }
    }
  
