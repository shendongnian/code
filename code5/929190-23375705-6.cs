        var list = new List<Test>();
        for(int k=0;k<100;k++) list.Add(
            new Test { Prop1 = Rnd(), /* random string of 1 MB */
                     Prop2 =k, Prop3=k*k, Prop4= DateTime.Now});
        BinaryFormatter(list);
        DataContractJsonSerializer(list);
        XmlSerializer(list);
        XmlSerializerBuffered(list);
        XmlSerializerMemory(list);
        XmlSerializerStringBuilder(list);
    }
