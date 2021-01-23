    //No reason to use identifier, just a default starting point that works for me.
	var identiferClassificationType = registryService.GetClassificationType("identifier");
	var classificationType = registryService.CreateClassificationType(name, SpecializedCollections.SingletonEnumerable(identiferClassificationType));
	var classificationFormatMap = ClassificationFormatMapService.GetClassificationFormatMap(category: "text");
	var identifierProperties = classificationFormatMap
		.GetExplicitTextProperties(identiferClassificationType);
		
	//Now modify the properties
	var color = System.Windows.Media.Colors.Yellow;
	var newProperties = identifierProperties.SetForeground(color);
	classificationFormatMap.AddExplicitTextProperties(classificationType, newProperties);
	//Now you can use or return classificationType...
