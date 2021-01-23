    static void xmlGenTest()
            {
                var doc = new XDocument();
    
                var x = new data_container();
                x.other_properties = new data_containerOther_properties { introduction_pic = "a", introduction_txt = "b" };
    
                x.people = new data_containerPerson[1];
                x.people[0] = new data_containerPerson
                {
                    p_id = "1",
                    some_data = new data_containerPersonSome_data { sx = data_containerPersonSome_dataSX.F }
                };
                using (var writer = doc.CreateWriter())
                {
                    var serializer = new XmlSerializer(x.GetType());
                    serializer.Serialize(writer, x);
                }
    
                Console.WriteLine(doc.ToString());
                Console.ReadKey();
                doc.Save("C:\\temp\\data.xml");
    
            }
