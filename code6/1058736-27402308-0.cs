    private Structure1[] GetFirstStructCollection()
        {
            return new[]
            {
                new Structure1
                {
                    Id = 1,
                    Name = "John Doe",
                    Description = "struct 1 test"
                },
                new Structure1
                {
                    Id = 2,
                    Name = "Sally Doe",
                    Description = "struct 1 test"
                }
            };
        }
        private Structure2[] GetSecondStructCollection()
        {
            return new[]
            {
                new Structure2
                {
                    Id = 1,
                Name = "Saphire Doe",
                Description = "struct 2 test"
                },
                new Structure2
                {
                    Id = 2,
                Name = "Onyx Doe",
                Description = "struct 2 test"
                }
            };
        }
            public ObservableCollection<object> GetDataByIndex2(int pIndex)
            {
                ObservableCollection<object> data = null;
                if (pIndex == 1)
                {
                    data = new ObservableCollection<object>(GetFirstStructCollection());
                }
                if (pIndex == 2)
                {
                    data = new ObservableCollection<object>(GetSecondStructCollection());
                }
                return data;
            }
