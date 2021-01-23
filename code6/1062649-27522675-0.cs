    var surveyTypeList = new XElement("SurveyTypes");
                foreach (var item in modelData.SurveyTypeList)
                {
                    if (item.IsSelected)
                    {
                        var surveyType = new XElement("SurveyType");
                        var id = new XElement("Id");
                        id.Add(item.Value);
                        surveyType.Add(id);
                        surveyTypeList.Add(surveyType);
                    }
                }
