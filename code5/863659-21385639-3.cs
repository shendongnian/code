                internal List<UserData> ConverToUserDataList(List<Training> TrainingList, List<Subject> AllSubjects)
        {
            List<UserData> userDataList = new List<UserData>();
            IEnumerable<Subject> usersSubjects;
            TrainingList.ForEach
            (
                t =>
                    t.Subjects.ForEach
                    (
                        s =>
                            s.Users.ForEach
                            (
                                u =>
                                    {
                                        usersSubjects = AllSubjects.Where(s2=>s2.Users.Contains(u));
                                        userDataList.Add
                                        (
                                            new UserData
                                            {
                                                UserId = u.UserId,
                                                FullName = u.FullName,
                                                SubjectNames = usersSubjects.Select(s2 => s2.Name).ToList(),
                                                TrainingNames = string.Join(
                                                                                ",",
                                                                                TrainingList.Where(t2 => t2.Subjects.Intersect(usersSubjects).Any()).Select(t2 => t2.Name).ToList()
                                                                            )
                                            }
                                        );
                                    }
                            )
                    )
            );
            return userDataList;
        }
