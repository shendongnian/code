        internal List<UserData> ConverToUserDataList(List<Training> TrainingList, List<Subject> AllSubjects)
        {
            List<UserData> userDataList = new List<UserData>();
            TrainingList.ForEach(t =>
                t.Subjects.ForEach(s =>
                    s.Users.ForEach(u =>
                      userDataList.Add(
                                 new UserData
                                 {
                                     UserId = u.UserId,
                                     FullName = u.FullName,
                                     SubjectNames = AllSubjects.Where(s2=>s2.Users.Contains(u)).Select(s2=>s2.Name).ToList(),
                                     TrainingNames = string.Join(",", TrainingList.Where(t2=>t2.Subjects.Where(s2=>s2.Users.Contains(u)).Select(t2=>t2.Name).ToList()));
                                 }
                                 ))));
            return userDataList;
        }
