    using System;
    using System.Xml;
    using System.Xml.Linq;
    
    class LinqToXmlDemo
    {
        static public void Main(string[] args)
        {
            string xmlContent = GetXml();
            var configFile = new ConfigurationFile(xmlContent);
    
            Console.WriteLine
                ("ConfigurationFilePath:[{0}]\n" +
                 "ConnectionString:[{1}]\n" +
                 "AnalyzeFilePath:[{2}]\n--",
                 configFile.ConfigurationFilePath,
                 configFile.ConnectionString,
                 configFile.AnalyzeFilePath);
        }
    
        static string GetXml()
        {
            return
                @"<?xml version='1.0' encoding='UTF-8'?>
                  <ConfigurationFile>
                      <ConfigurationFilePath>Test1</ConfigurationFilePath>
                      <ConnectionString>Test2</ConnectionString>
                      <AnalyzeFilePath>Test3</AnalyzeFilePath>
                  </ConfigurationFile>";
        }
    }
    
    public class ConfigurationFile
    {
        public String ConfigurationFilePath { get; set; }
        public String ConnectionString { get; set; }
        public String AnalyzeFilePath { get; set; }
    
        public ConfigurationFile(String xml)
        {
            XDocument document = XDocument.Parse(xml);
            var root = document.Root;
    
            ConfigurationFilePath = (string)root.Element("ConfigurationFilePath");
            ConnectionString = (string)root.Element("ConnectionString");
            AnalyzeFilePath = (string)root.Element("AnalyzeFilePath");
        }
    }
