        private class User
        {
            public string UserName { get; set; }
        }
        [TestMethod]
        public void TwoListsWithSameUsersReturnCorrectCountOfEquality()
        {
            var user1 = new User { UserName = "Tim" };
            var user2 = new User { UserName = "Bob" };
            var user3 = new User { UserName = "Brian" };
            var user4 = new User { UserName = "Paul" };
            IList<string> List1 = new List<string> 
                    { user1.UserName, user2.UserName, user3.UserName, user4.UserName };
            IList<string> List2 = new List<string> { "Tim", "Bob", "Brian", "Paul" };
            var sameUser = List1.Distinct().Intersect(List2.Distinct());
            Assert.AreEqual(4, sameUser.Count());
        }
