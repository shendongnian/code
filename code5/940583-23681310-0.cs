	var doc = XDocument.Parse(xml);
	// create namespace of TPX
	var ns = XNamespace.Get(@"http://www.garmin.com/xmlschemas/ActivityExtension/v2");
	// get TPX node using the namespace
	var tpx = doc.Root.Element("Extensions").Element(ns + "TPX");
	// retrieve Speed and Watts using the namespace
	var speed = tpx.Element(ns + "Speed");
	var watts = tpx.Element(ns + "Watts");
	Console.WriteLine("{0} - {1}", speed.Value, watts.Value);
