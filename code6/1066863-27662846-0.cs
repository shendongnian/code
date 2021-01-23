            public void MyMethod(params Contact[] contacts)
            {
                var list = new List<Contact>(contacts);
                list.Add(list[0]);
                // ... do your thing
            }
