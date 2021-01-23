    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    
    namespace BuildTasks
    {
        public class AddFilesToProject : Task
        {
            [Required]
            public string ProjectPath { get; set; }
    
            [Required]
            public string FilePath { get; set; }
    
            [Required]
            public string BinPath { get; set; }
    
            [Required]
            public string HooksPath { get; set; }
    
            [Required]
            public string ProjectDir { get; set; }
    
    
            /// <summary>
            /// When overridden in a derived class, executes the task.
            /// </summary>
            /// <returns>
            /// true if the task successfully executed; otherwise, false.
            /// </returns>
            public override bool Execute()
            {
    
                try
                {
                    var binRelative = BinPath.Replace(ProjectDir + "\\", "");
                    var hooksRelative = HooksPath.Replace(ProjectDir + "\\", "");
                    var fileRelative = FilePath.Replace(ProjectDir + "\\", "");
                    XDocument document = XDocument.Load(ProjectPath);
                    XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";
    
                    bool foundBin = false;
                    bool foundHooks = false;
                    bool foundFile = false;
                    XElement itemGroup = null;
                    foreach (XElement el in document.Descendants(ns + "ItemGroup"))
                    {
                        foreach (XElement item in el.Descendants(ns + "Compile"))
                        {
                            itemGroup = el;
                            if (item.Attribute("Include").Value.Contains(binRelative))
                            {
                                foundBin = true;
                                Log.LogMessage(MessageImportance.Low, "FoundBin: {0}", foundBin);
                            }
                            else if (item.Attribute("Include").Value.Contains(hooksRelative))
                            {
                                foundHooks = true;
                                Log.LogMessage(MessageImportance.Low, "FoundHooks: {0}", foundHooks);
                            }
                            else if (item.Attribute("Include").Value.Contains(fileRelative))
                            {
                                foundFile = true;
                                Log.LogMessage(MessageImportance.Low, "FoundFile: {0}", foundFile);
                            }
                        }
                    }
    
                    if (!foundBin)
                    {
                        XElement item = new XElement(ns + "Compile");
                        item.SetAttributeValue("Include", binRelative);
                        if (itemGroup != null) itemGroup.Add(item);
                    }
                    if (!foundHooks)
                    {
                        XElement item = new XElement(ns + "Compile");
                        item.SetAttributeValue("Include", hooksRelative);
                        if (itemGroup != null) itemGroup.Add(item);
                    }
                    if (!foundFile)
                    {
                        XElement item = new XElement(ns + "Compile");
                        item.SetAttributeValue("Include", fileRelative);
                        if (itemGroup != null) itemGroup.Add(item);                    
                    }
                    if (!foundBin || !foundHooks || !foundFile)
                    {
                        document.Save(ProjectPath);
                    }
                }
                catch (Exception e)
                {
                    Log.LogErrorFromException(e);
                }
    
                return !Log.HasLoggedErrors;
            }
        }
    }
