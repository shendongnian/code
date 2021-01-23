        using System;
        using System.Collections.Generic;
        using System.Linq;
        namespace SO
        {
            class Program
            {
                static void Main(string[] args)
                {
                    // Create Students List
                    var students = new List<Student>()
                    {
                        new Student
                        {
                            FirstName = "Paul",
                            LastName = "Smith",
                            ActivityList = new List<Activity>() { 
                                new Activity
                                {
                                    ActivityName = "Math", ActivityScore = 90                        
                                },
                               new Activity
                                {
                                    ActivityName = "Biology", ActivityScore = 92                        
                                },
                               new Activity
                                {
                                    ActivityName = "C#", ActivityScore = 93                        
                                }
                            }
                        },
                        new Student
                        {
                            FirstName = "Mary",
                            LastName = "Jones",
                            ActivityList = new List<Activity>() { 
                                new Activity
                                {
                                    ActivityName = "Linq", ActivityScore = 95                       
                                },
                               new Activity
                                {
                                    ActivityName = "Phyics", ActivityScore = 99                        
                                },
                               new Activity
                                {
                                    ActivityName = "C#", ActivityScore = 99                        
                                }
                            }
                        },
                        new Student
                        {
                            FirstName = "Slick",
                            LastName = "Willy",
                            ActivityList = new List<Activity>() { 
                                new Activity
                                {
                                    ActivityName = "Wine", ActivityScore = 90                        
                                },
                               new Activity
                                {
                                    ActivityName = "Women", ActivityScore = 99                        
                                },
                               new Activity
                                {
                                    ActivityName = "Politics", ActivityScore = 85                        
                                }
                            }
                        }
                    };
                    // Created a sorted list of activity Names
                    var activities = (from s in students from a in s.ActivityList select (a.ActivityName)).Distinct().ToList();
                    activities.Sort();
                    // Create a Tuple of <Name,Activities>
                    var grid = students.DataGrid(activities);
                    // Print Header
                    System.Diagnostics.Debug.Write(string.Format("{0,-12}", "Name"));
                    foreach (var item in activities)
                    {
                       System.Diagnostics.Debug.Write(string.Format("{0,12}",item));
                    }
                    System.Diagnostics.Debug.WriteLine("");
                    // Print Rows
                    foreach (var t in grid)
                    {
                        System.Diagnostics.Debug.Write(string.Format("{0,-12}", t.Item1));
                        foreach (var s in t.Item2)
                        {
                            System.Diagnostics.Debug.Write(string.Format("{0,12}", s));
                        }
                        System.Diagnostics.Debug.WriteLine("");
                    }
                    // Done
                }
            }
        public class Student
        {
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public List<Activity> ActivityList { get; set; }
        }    
        public class Activity
        {
            public String ActivityName { get; set; }
            public int ActivityScore { get; set; }
        }
        public static class LinqExt2
        {
            public static IEnumerable<Tuple<string, System.Collections.Generic.List<int>>> DataGrid<T>(this IEnumerable<T> source, IEnumerable<string> columnList)
            {
                using (var iterator = source.GetEnumerator())
                {
                    // A List of Tuples in the format <string, List<int>>
                    var results = new List<Tuple<string, List<int>>>();
                    // each Student
                    while (iterator.MoveNext())
                    {
                        var a = iterator.Current as Student;
                        if (a == null)
                            continue;
                        // initalize all cols to 0;
                        var columnValues = columnList.Select(v => 0).ToList();
                        // each Activity
                        foreach (var item in a.ActivityList)
                        {
                            var name = item.ActivityName;
                            var i = 0;
                            foreach (var activity in columnList)
                            {
                                if (name.Equals(activity))
                                {
                                    columnValues[i] = item.ActivityScore;
                                    break;
                                }
                                i++;
                            }
                        }
                        results.Add(Tuple.Create(a.FirstName, columnValues));
                    }
                    return results;
                }
            }
        }
        }
