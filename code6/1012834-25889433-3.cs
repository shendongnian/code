		[HttpPost]
		public ActionResult Assessment(string Id,string ExamsScore,string TestAggregate) 
		{        /// split here above input values 
			/// convert to int and then process
				var students = _studentService.getNurStudentbyClass(Id).Select(x => x.Id);
				foreach (var id in students)
				{
					if (model.ExamsScore == 0)
					{
						if (model.TestAggregate != 0)
						{
							model.ExamsScore = 0;
							model.TotalScore = model.TestAggregate + model.ExamsScore; 
							_recordService.CreateResult(model.TestAggregate,model.ExamsScore,model.ExamsScore,model.Grade,model.TermId,model.SubjectId,id,model.SessionId);
						}
					}
				}
			}
			return View();
		}
