    Take and Skip:
    context.UserAssessments.Where(a=>a.UserID == UserID && a.CourseID == ClassID && a.ProductID == a.ProductID && a.AppID == ApplicationID && a.IsDeleted == false && a.Score_Percentage >= 0).Select(a=> new UserAssessmentEntity()
                                              {
                                                  ApplicationID = a.AppID,
                                                  AttemptNo = a.AttemptNo,
                                                  CourseID = a.CourseID,
                                                  Score_Percentage = (float)(a.Score_Percentage != null ? a.Score_Percentage : 0),
                                                  Status = a.Status,
                                                  UserAssessmentID = a.UserAssessmentID,
                                                  UserID = a.UserID,
                                                  UserScore = a.User_Score,
                                                  CreatedDateTime = a.CreatedDateTime,
                                                  ModifiedDateTime = a.ModifiedDateTime,
                                                  TimeSpent=a.UserAssessmentDetails.Sum(i=>i.TimeSpent??0),
                                                  InstructorFeedbackText = a.UserAssessmentDetails.FirstOrDefault()!=null?a.UserAssessmentDetails.FirstOrDefault().InstructorFeedbackText:string.Empty
                                              }).Take(10).Skip(10).ToList();
