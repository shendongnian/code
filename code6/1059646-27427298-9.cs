    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using XMLSerializationDemo;
    
    namespace UnitTest
    {
        [TestClass]
        public class UnitTest
        {
            [TestMethod]
            public void DummyData_TestDataCreated()
            { 
                //Arrange
                PrivateType pt = new PrivateType(typeof(Program));
    
                //Act
                RUBIObjectCollection collection = (RUBIObjectCollection)pt.InvokeStatic("DummyData", null);
                int actualResult = collection.Objects.Count;
                int expectedResult = 10;
    
                //Assert
                Assert.AreEqual(actualResult, expectedResult);
            }
    
            [TestMethod]
            public void SerializeToXML_GeneratesXMLString()
            {
                //Arrange
                bool actualResult = false;
                bool expectedResult = true;
                PrivateType pt = new PrivateType(typeof(Program));
                RUBIObjectCollection collection = (RUBIObjectCollection)pt.InvokeStatic("DummyData", null);
    
                //Act
                string serializedXml = collection.SerializeToXML();
    
                try
                {      
                    System.Xml.Linq.XDocument doc = System.Xml.Linq.XDocument.Parse(serializedXml);
    
                    actualResult = true;
                }
                catch
                {
                    actualResult = false;
                }
    
                //Assert
                Assert.AreEqual(actualResult, expectedResult);
            }
    
            [TestMethod]
            public void DeserializeToCollection_DeserializedToRUBICollection()
            { 
                //Arrange 
                bool actualResult = false;
                bool expectedResult = true;
                XMLSerializationDemo.RUBIObjectCollection deserializedCollection = null;
                PrivateType pt = new PrivateType(typeof(XMLSerializationDemo.Program));
                XMLSerializationDemo.RUBIObjectCollection collection = (XMLSerializationDemo.RUBIObjectCollection)pt.InvokeStatic("DummyData", null);
                string serializedXml = collection.SerializeToXML();
                
                //Act
                try
                {
                    deserializedCollection = serializedXml.DeserializeToCollection();
                    if (deserializedCollection.Objects.Count > 0)
                        actualResult = true;
                }
                catch
                {
                    actualResult = false;
                }
    
                //Assert
                Assert.AreEqual(actualResult, expectedResult);
            }
        }
    }
