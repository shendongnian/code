            /// <summary>
            /// This method adds a file to the Word.ApplicationClass object's current selection.
            /// Has been tested with word (*.doc)documents but not with other office files.
            /// Other files may work also with this method.
            /// Tested with the Microsoft 9.0 Object Library ( COM )
            /// </summary>
            /// <param name="WordApp">The Word.ApplicationClass object</param>
            /// <param name="DirLocation">A string that contains the file directory location.</param>
            /// <param name="FileName">A string that contains the file name within the directory location.</param>
            public static void InsertFile(Word.ApplicationClass WordApp, string DirLocation, string FileName)
            {
                try
                {
                    object j_NullObject = System.Reflection.Missing.Value;
                    WordApp.Selection.InsertFile(DirLocation + FileName, ref j_NullObject, ref j_NullObject, ref j_NullObject, ref j_NullObject);
                }
                //An Exception will occur when the Directory location and filename does not exist.
                //An Exception may also occur when the Word.ApplicationClass has no Selection to add
                //the file to.
                catch (Exception e)
                {
                    //show the user the error message
                    MessageBox.Show(e.Message);
                    //log the error
                    //ErrorLog.LogError(e);
                }
            }
