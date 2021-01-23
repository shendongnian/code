       using System.Xml;
       class MyVSTOClass : IMy35AssembyInterface // This caused the error
       class MyVSTOClass : IXmlSerializable      // This compiled OK 
    
       using System.Xml;
       interface IMy35AssembyInterface : IXmlSerializable
