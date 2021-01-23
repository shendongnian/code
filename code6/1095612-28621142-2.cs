    using System.Collections.Generic;
    public class LoopExample
    {
         public void RunLoopExample()
         {
              var outerList = new string[]{"the", "quick", "brown", "fox"};
              var innerList = new string[]{"jumps", "over", "the", "lazy", "dog"};
              // define the resultList variable outside the outer loop
              var resultList = new List<string>();
              for(int outerIndex = 0; outerIndex < outerList.Length; outerIndex ++)
              {
                  var outerValue = outerList[outerIndex];
                  for(int innerIndex = 0; innerIndex < innerList.Length; innerIndex++)
                  {
                      var innerValue = innerList[innerIndex];
                      resultList.Add(string.Format("{0}->{1}; ", outerValue, innerValue));
                  }
              }
              // use the resultList variable outside the outer loop
              foreach(var result in resultList )
              {
                  Console.WriteLine(result);
              }
         }
    }
