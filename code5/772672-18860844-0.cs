            LinkedList<Double> list = new LinkedList<Double>();
            double sumOfSquares = 0;
            double deviation;
            double delta;
            list.AddLast(2);
            list.AddLast(4);
            list.AddLast(4);
            list.AddLast(4);
            list.AddLast(5);
            list.AddLast(5);
            list.AddLast(7);
            list.AddLast(9);
            double average = list.Average();
            Console.WriteLine("Average: " + average);
            foreach (double item in list)
            {
                delta = Math.Abs(item - average);
                sumOfSquares += (delta * delta);
            }
            Console.WriteLine("Sum of Squares: " + sumOfSquares);
            deviation = Math.Sqrt(sumOfSquares / list.Count());
            Console.WriteLine("Standard Deviation: " + deviation); //Final result is 2.0
