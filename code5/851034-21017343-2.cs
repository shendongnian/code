    foreach (var absentDate in doc.Element("Classworks").Descendants("Classwork"))
    {
    	serviceDate = absentDate.Element("ClassworkDate").Value.ToString();
    	name = absentDate.Element("Subject").Value.ToString();
    	taskname = absentDate.Element("Task").Value.ToString();
    	var newModel = new MyModel{
    								 ClassworkDate = serviceDate,
    								 Subject = name,
    								 Task = taskname
    							   };
        MyItemsSource.Add(newModel);
    }
