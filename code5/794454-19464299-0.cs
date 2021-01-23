            [TestMethod]
            public void Test()
            {
                Employee e1 = new Employee { E1 = 7 };
                Employee e2 = new Employee { E2 = 78 };
                Mapper.CreateMap<Employee, Employee>().ForMember(x => x.E1, x => x.Ignore());
                var de1 = Mapper.Map<Employee, Employee>(e2, e1);
                //de1.E1 is 7.               
            }
