	var myDerivedObj = new MyDerivedClass { Id = 1, Name = "Test", Patronymic = "Patronymic" };
	var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
	var myDerivedString = serializer.Serialize(myDerivedObj);
	var myBaseObj = myDerivedObj.ToType<MyBaseClass>(); //Converting
	var myBaseString = serializer.Serialize(myBaseObj); //This string is what you want
