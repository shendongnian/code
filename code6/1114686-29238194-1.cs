       // Single category class
       public class MyCategory
       {
          public string Title { get; set; }
          public Dictionary<string, MyCategory> Children { get; set; }
    
          // Constructor
          public MyCategory(string title)
          {
             Title = title;
             Children = new Dictionary<string, MyCategory>();
          }
       }
    
    
       internal class SO29235482
       {
          // Dictionary for the root nodes
          private readonly Dictionary<string, MyCategory> _categoryTree = 
                                                                new Dictionary<string, MyCategory>();
    
    
          public void JustTesting()
          {
             AddCategoryToTree("A > A1 > A1-1");
             AddCategoryToTree("A > A1 > A1-2");
             AddCategoryToTree("A > A1 > A1-3");
             AddCategoryToTree("A > A2 > A2-1");
             AddCategoryToTree("A > A2 > A2-2");
             AddCategoryToTree("B > B1 > B1-1");
             AddCategoryToTree("C > C1 > C1-1");
    
             if (AddCategoryToTree("C > C1 > C1-1"))
                throw new Exception("Incorrect return value for existing entry.");
          }
    
    
          /// <summary>
          /// Method to add (if necessary) a category to the category tree. (No input error checking is 
          /// done - this is simple "proof of concept" code.
          /// </summary>
          /// <param name="textInput">titles separated by '>', for example "A > A1 > A1-1"</param>
          /// <returns>true = category added, false = already in tree</returns>
          public bool AddCategoryToTree(string textInput)
          {
             // Parse the input - no error checking done
             string[] titleArray = textInput.Split('>');
    
             // Use recursive method to add the nodes to the tree, if not already there
             return AddNodesToTree(titleArray, 0, _categoryTree);
          }
    
    
          /// <summary>
          /// Recursive method to process each level in the input string, creating a node if necessary 
          /// and then calling itself to process the next level.
          /// </summary>
          private static bool AddNodesToTree(string[] titleArray, int thisIndex, 
                                             Dictionary<string, MyCategory> priorDictionary)
          {
             if (thisIndex >= titleArray.Length)
                return false;
    
             bool treeUpdated = false;
             
             // Create node entry in prior Dictionary if not already there
             string thisTitle = titleArray[thisIndex].Trim();
             MyCategory thisNode;
             if (!priorDictionary.TryGetValue(thisTitle, out thisNode))
             {
                thisNode = new MyCategory(thisTitle);
                priorDictionary.Add(thisTitle, thisNode);
                treeUpdated = true;
             }
    
             // Process the lower-level nodes using recursive method
             return AddNodesToTree(titleArray, ++thisIndex, thisNode.Children) | treeUpdated;
          }
       }
