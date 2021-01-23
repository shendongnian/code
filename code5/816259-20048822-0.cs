    ...
    XmlSerializer ser = new XmlSerializer(typeof(A));
	ser.Serialize(new XmlTextWriter("C:\\Users\\schumann\\Documents\\test.xml", Encoding.Default), foo);
    ...			
    [System.Xml.Serialization.XmlRoot("Root", Namespace = "DefaultNS")]
	[System.Xml.Serialization.XmlInclude(typeof(B))]
	public class A { public int a;}
	[System.Xml.Serialization.XmlRoot(Namespace = "CustomNS")]
	public class B : A { public int b;}
