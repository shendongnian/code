     private void SetPeopleEditor(SPListItem item, string columnName, PeopleEditor peopleEditor, SPWeb web)
            {
                if (item[columnName] != null)
                {
                    char[] to_splitter = { ';' };
                    string to_list = item[columnName].ToString(); // Reads value stored in SPList. (i.e., "Domain\User1; Domain\User2")
                    string[] arr = to_list.Split(to_splitter);
                    string user = string.Empty;
                    for (int i = 1; i < arr.Length; i++)
                    {
                        if ((i % 2) != 0)
                        {
                            user = arr[i].Substring(arr[i].IndexOf("#") + 1);
                           PickerEntity entity  = new PickerEntity();
                            entity.Key = user;
                            entity.IsResolved = true;
                            entity = peopleEditor.ValidateEntity(entity);
                            peopleEditor.Entities.Add(entity);
                        }
                    }
                }
            }
