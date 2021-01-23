    public static class TextBoxCollectionExtensions
    {
        /// <summary>
        /// Extension method that determines whether the list of textboxes contains a text value.
        /// (Optionally, you can pass in a list of textboxes or keep the method in the class that contains the local list of textboxes.
        /// There is no right or wrong way to do this. Just preference and utility.)
        /// </summary>
        /// <param name="str">String to look for within the list.</param>
        /// <returns>Returns true if found.</returns>
        public static bool IsDuplicateText(this List<TextBox> textBoxes, string str)
        {
            //Just a note, the query has been spread out for readability and better understanding.
            //It can be written Inline as well. (  ex. var result = someCollection.Where(someItem => someItem.Name == "some string").ToList();  )
            //Using Lambda, query against the list of textboxes to see if any of them already contain the same string. If so, return true.
            return textBoxes.AsQueryable()                  //Convert the IEnumerable collection to an IQueryable
                .Any(                                       //Returns true if the collection contains an element that meets the following condition.
                    textBoxRef => textBoxRef                //The => operator separates the parameters to the method from it's statements in the method's body.
                                                            //      (Word for word - See http://www.dotnetperls.com/lambda for a better explanation)
                        .Text.ToLower() == str.ToLower()    //Check to see if the textBox.Text property matches the string parameter
                                                            //      (We convert both to lowercase because the ASCII character 'A' is not the same as the ASCII character 'a')
                    );                                      //Closes the ANY() statement
        }
    } 
