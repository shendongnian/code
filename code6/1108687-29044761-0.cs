    using System;
    using System.Collections.Generic;
    namespace MathQuiz
    {
        class Program
        {
            interface IExercise
            {
                string Title { get; }
                void Generate();
            }
            abstract class Exercise<TResult> : IExercise
            {
                public virtual string Title
                {
                    get
                    {
                        return "Exercise";
                    }
                }
                public abstract bool isCorrect(TResult reply);
                public abstract TResult Solve();
                public abstract bool TryParse(string value, out TResult result);
                public abstract void Generate();
            }
            abstract class ExerciseWith2Items<TSource, TResult> : Exercise<TResult>
            {
                public virtual TSource Item1 { get; set; }
                public virtual TSource Item2 { get; set; }
                public abstract string Operator { get; }
                public override string ToString()
                {
                    return string.Format("{0} {1} {2}", Item1, Operator, Item2);
                }
            }
            abstract class WholeNumberExercise : ExerciseWith2Items<int, int>
            {
                public override void Generate()
                {
                    Random next = new Random();
                    Item1 = next.Next(100) + 15;
                    Item2 = next.Next(100) + 15;
                }
                public override bool TryParse(string value, out int result)
                {
                    return int.TryParse(value, out result);
                }
            }
            class Division : WholeNumberExercise
            {
                protected bool IsPrime(int nr)
                {
                    int max = (int)Math.Sqrt(nr);
                    if (nr <= 2)
                    {
                        return true;
                    }
                    for (int i = 2; i < max; i++)
                    {
                        if (nr % i == 0)
                        {
                            return false;
                        }
                    }
                    return true;
                }
                public override int Item1
                {
                    get
                    {
                        return base.Item1;
                    }
                    set
                    {
                        // primes cannot be divived, so increase the value until we don't have a prime
                        while (IsPrime(value))
                        {
                            value++;
                        }
                        base.Item1 = value;
                    }
                }
                public override int Item2
                {
                    get
                    {
                        return base.Item2;
                    }
                    set
                    {
                        if (value <= 0)
                        {
                            // minimum 2
                            value = 2;
                        }
                        // small override: we only want whole number division, so change the nr to the closest nr that has no rest after division
                        int closest = 0;
                        while ((value - closest > 1 && Item1 % (value - closest) != 0) ||
                            (value + closest < Item1 && Item1 % (value  + closest) != 0))
                        {
                            closest++;
                        }
                        // in case closest == 0, it doesn't really change anything
                        if (Item1 % (value - closest) == 0)
                        {
                            value -= closest;
                        }
                        else
                        {
                            value += closest;
                        }
                        base.Item2 = value;
                    }
                }
                public override string Operator
                {
                    get { return "/"; }
                }
                public override bool isCorrect(int reply)
                {
                    return reply == (Item1 / Item2);
                }
                public override void Generate()
                {
                    Random r = new Random();
                    Item1 = r.Next(500) + 100;
                    Item2 = r.Next(50) + 2;
                }
                public override int Solve()
                {
                    return (Item1 / Item2);
                }
            }
            class Multiplication : WholeNumberExercise
            {
                public override string Operator
                {
                    get { return "*"; }
                }
                public override bool isCorrect(int reply)
                {
                    return reply == (Item1 * Item2);
                }
                public override int Solve()
                {
                    return (Item1 * Item2);
                }
            }
            class Addition : WholeNumberExercise
            {
                public override string Operator
                {
                    get { return "+"; }
                }
                public override bool isCorrect(int reply)
                {
                    return reply == (Item1 + Item2);
                }
                public override int Solve()
                {
                    return (Item1 + Item2);
                }
            }
            class Subtraction : WholeNumberExercise
            {
                public override string Operator
                {
                    get { return "-"; }
                }
                public override bool isCorrect(int reply)
                {
                    return reply == (Item1 - Item2);
                }
                public override int Solve()
                {
                    return (Item1 - Item2);
                }
            }
            static IExercise ShowMenu(IList<IExercise> exercises)
            {
                int menu;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Test your match skills :)\r\n");
                    for (int i = 0; i < exercises.Count; i++)
                    {
                        Console.WriteLine("\t{0}\t{1}", i, exercises[i].GetType().Name);
                    }
                    Console.WriteLine("\r\n\t99\tExit\r\n");
                    Console.Write("Please enter your choice: ");
                    if (!int.TryParse(Console.ReadLine(), out menu))
                    {
                        // wrong input
                        menu = -1;
                    }
                    if (menu != 99)
                    {
                        if (menu >= exercises.Count)
                        {
                            menu = -1;
                        }
                    }
                }  while (menu < 0);
                IExercise result = null;
                if (menu != 99)
                {
                    result = exercises[menu];
                }
                return result;
            }
            static void Solve(IExercise exercise)
            {
                if (exercise == null)
                {
                    return;
                }
                if (!(exercise is WholeNumberExercise))
                {
                    Console.WriteLine("Don't know how to solve this exercise, please contact developer :)");
                    Console.ReadLine();
                    return;
                }
                var solvable = exercise as WholeNumberExercise;
                solvable.Generate();
                Console.Write("{0}: '{1}' = ", solvable.GetType().Name, exercise);
                int reply;
                bool validAnswerGiven;
                do
                {
                    validAnswerGiven = solvable.TryParse(Console.ReadLine(), out reply);
                    if (validAnswerGiven)
                    {
                        if (solvable.isCorrect(reply))
                        {
                            Console.WriteLine("Correct!");
                        }
                        else
                        {
                            Console.WriteLine("Incorrect, the correct result is {0}", solvable.Solve());
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter valid value (whole number)!");
                    }
                } while (!validAnswerGiven);
                Console.ReadLine();
            }
            static void Main(string[] args)
            {
                IList<IExercise> potentialExercises = new List<IExercise>()
                {
                    new Addition(),
                    new Subtraction(),
                    new Division(),
                    new Multiplication() 
                };
                IExercise selectedExercise;
                do
                {
                    selectedExercise = ShowMenu(potentialExercises);
                    Solve(selectedExercise);
                } while (selectedExercise != null);
                Console.WriteLine("Program completed!");
            }
        }
    }
