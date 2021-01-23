        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace FundRaiser
    {
        class Program
        {
            public class GradeContribution
            {
                public GradeContribution()
                {
                    this.Count = 0;
                    this.Total = 0.0;
                    this.Average = 0.0;
                }
    
                int grade;
    
                public int Grade
                {
                    get { return grade; }
                    set { grade = value; }
                }
                int count;
    
                public int Count
                {
                    get { return count; }
                    set { count = value; }
                }
                double total;
    
                public double Total
                {
                    get { return total; }
                    set { total = value; }
                }
                double average;
    
                public double Average
                {
                    get { return average; }
                    set { average = value; }
                }
    
            }
    
            public class SchoolFundRaiser
            {
                Dictionary<int, GradeContribution> contributionReciept;
    
                public SchoolFundRaiser()
                {
                    contributionReciept = new Dictionary<int, GradeContribution>();
                }
    
                public void CalculateContribution()
                {
                    int grade = 0;
                    while (grade != 999)
                    {
                        Console.WriteLine("Please Enter your grade(6, 7, 8).\n (Enter 999 to quit):");
                        grade = Convert.ToInt32(Console.ReadLine());
    
                        if (grade != 999)
                        {
                            GetContribution(grade);
                        }
                        else
                        {
                            Console.WriteLine("Exiting...");
                            DisplayContribution();
                        }
                    }
                }
    
                void GetContribution(int grade)
                {
                    Console.WriteLine("Please Enter the Amount you want to contribute. ");
                    double contribution = Convert.ToDouble(Console.ReadLine());
    
                    if (contributionReciept.ContainsKey(grade))
                    {
                        GradeContribution contribute = contributionReciept[grade];
                        contribute.Count++;
                        contribute.Total += contribution;
                        contribute.Average = (contribute.Total / contribute.Count);
                    }
                    else
                    {
                        GradeContribution contribute = new GradeContribution();
                        contribute.Grade = grade;
                        contribute.Count++;
                        contribute.Total += contribution;
                        contribute.Average = (contribute.Total / contribute.Count);
                        contributionReciept.Add(grade,contribute);
                    }
                }
    
                void DisplayContribution()
                {
                    var list = contributionReciept.Keys.ToList();
                    list.Sort();
    
                    Console.WriteLine("Grade \t" + "Num of Contributions \t" + "Total Contribution \t" + "Average contribution");
    
                    foreach (var grade in list)
                    {
                        GradeContribution gc = contributionReciept[grade];
                        Console.WriteLine(gc.Grade + "\t" + gc.Count + "\t" + gc.Total + "\t" + gc.Average);
                    }
                }
            }
    
            static void Main(string[] args)
            {
                SchoolFundRaiser testSchoolFundRaiser = new SchoolFundRaiser();
                testSchoolFundRaiser.CalculateContribution();
            }
        }
    }
