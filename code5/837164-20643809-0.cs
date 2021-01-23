			using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			
			namespace ConsoleApplication12
			{
			    class Program
			    {
			
			        private string[] Stack = new string[5];
			        private int nextFree;
			
			        public Program()
			        {
			            Stack = new string[10];
			            Stack[0] = "Greg";
			            Stack[1] = "Matt";
			            Stack[2] = "Jack";
			            Stack[3] = "Fred";
			            nextFree = 4;
			        }
			
			        static void Main(string[] args)
			        {
			            Program prog = new Program();
			            do
			            {
			                prog.DisplayMenu();
			            }
			            while (true);
			        }
			
			
			
			
			        public void DisplayMenu()
			        {
			            Int32 userInput = 0;
			
			            Console.WriteLine("Linear Stack");
			            Console.WriteLine("1: Add to stack");
			            Console.WriteLine("2: Delete from stack");
			            String s = Console.ReadLine().Trim();
			            try
			            {
			                userInput = Int32.Parse(s);
			            }
			            catch (Exception)
			            {
			                userInput = 1;
			            }
			
			            switch (userInput)
			            {
			                case 1:
			                    this.Push();
			                    break;
			
			                case 2:
			                    this.Pop();
			                    break;
			            }
			
			        }
			
			
			        public void Push()
			        {
			            if (nextFree == Stack.Length)
			            {
			                Console.WriteLine("Stackoverflow, to many elements for the stack");
			                Console.ReadLine();
			            }
			            else
			            {
			                Console.WriteLine("Please enter a name to be added");
			                string userInput = Console.ReadLine();
			                Stack[nextFree] = userInput;
			                nextFree++;
			            }
			            this.List();
			        }
			
			
			        public String Pop()
			        {
			            if (nextFree == 0)
			            {
			                Console.WriteLine("Stack is empty");
			                return null;
			            }
			            else
			            {
			                String res = Stack[nextFree - 1];
			                nextFree--;
			                this.List();
			                return res;
			            }
			        }
			
			        public void List()
			        {
			            for (int k = 0; k < nextFree; k++)
			            {
			                Console.Write(this.Stack[k] + " ");
			            }
			            Console.WriteLine();
			        }
			    }
			
			}
			
			
			
			
			
			
			
