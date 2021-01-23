    var tc = XElement.Load("C:/Users/mkumar/Documents/testcase.xml");
    var testCase = new CommonLib.TestCase {
                       date = (string)tc.Element("date"),
                       name = (string)tc.Element("name"),
                       sub= (string)tc.Element("subject")
                    };
