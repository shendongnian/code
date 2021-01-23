	var settings = new DataContractJsonSerializerSettings();
	settings.UseSimpleDictionaryFormat = true;
	DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(StudyPlanResponse), settings);
	StudyPlanResponse studyplan;
	using (var stream = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(jsrc)))
	{
		studyplan = (StudyPlanResponse)ser.ReadObject(stream);
	}
