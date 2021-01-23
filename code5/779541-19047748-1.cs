            var nodeList = new List<TempTreeNode>();
                
            using (var command = new SqlCommand(_Query, _Connection))
            {
                _Connection.Open();
                var _Reader = command.ExecuteReader();
                while (_Reader.Read())
                {
                    var node = new TempTreeNode()
                    {
                        MenuID = (int)_Reader["MenuID"],
                        ParentID = (int)_Reader["ParentID"],
                        Rank = (int)_Reader["Rank"],
                        Lang = _Reader["English"].ToString()
                    };
                    nodeList.Add(node);
                }
                _Connection.Close();
            }
            // sorting
            nodeList.Sort((a, b) => a.Rank.CompareTo(b.Rank));
            // creation
            CreateNodes(nodeList);
