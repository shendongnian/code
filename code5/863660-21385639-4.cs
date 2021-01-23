                internal List<UserData> ConverToUserDataList(List<Training> TrainingList, List<Subject> AllSubjects)
        {
            List<UserData> userDataList = new List<UserData>();
            IEnumerable<Subject> usersSubjects;
            TrainingList.ForEach
            (
                training =>
                    training.Subjects.ForEach
                    (
                        subject =>
                            subject.Users.ForEach
                            (
                                user =>
                                    {
                                        usersSubjects = AllSubjects.Where(subjectB => subjectB.Users.Contains(user));
                                        userDataList.Add
                                        (
                                            new UserData
                                            {
                                                UserId = user.UserId,
                                                FullName = user.FullName,
                                                SubjectNames = usersSubjects.Select(subjectB => subjectB.Name).ToList(),
                                                TrainingNames = string.Join(
                                                                                ",",
                                                                                TrainingList.Where(trainingB => trainingB.Subjects.Intersect(usersSubjects).Any()).Select(trainingB => trainingB.Name).ToList()
                                                                            )
                                            }
                                        );
                                    }
                            )
                    )
            );
            return userDataList;
        }
