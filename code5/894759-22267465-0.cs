            /// <summary>
            /// Return a list of string containing all the codes
            /// </summary>
            /// <returns>List of codes</returns>
            private List<string> GetListOfCodes()
            {
                return
                    (from DataGridViewRow row in gvsale.Rows
                          select (string)row.Cells[0].Value).ToList();
            }
