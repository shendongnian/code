	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.SolverFoundation.Services;
	namespace XmasDrawCSP
	{
		public class Class1
		{
			public static void Main(string[] args)
			{
				var Names = new string[] { 
					"Alice", "Bob", "Carol", "David", "Eve",
				};
				Domain Recipients = Domain.Enum(Names);
				SolverContext context = SolverContext.GetContext();
				Model model = context.CreateModel();
				Dictionary<string, string[]> PossiblyBuysFor = new Dictionary<string, string[]>();
				//Alice and Carol are sisters
				//Bob and David are brothers
				//Can't buy for siblings or yourself
				PossiblyBuysFor["Alice"] = new string[] { "Bob", "David", "Eve", };
				PossiblyBuysFor["Bob"] = new string[] { "Alice", "Carol", "Eve", };
				PossiblyBuysFor["Carol"] = new string[] { "Bob", "David", "Eve", };
				PossiblyBuysFor["David"] = new string[] { "Alice", "Carol", "Eve", };
				PossiblyBuysFor["Eve"] = new string[] { "Alice", "Bob", "Carol", "David", };
				foreach (var giver in PossiblyBuysFor.Keys)
				{
					Decision d = new Decision(Recipients, giver.ToLower());
					model.AddDecision(d);   
				}
				foreach (var giver in PossiblyBuysFor.Keys)
				{
					string term = "1 == 0 ";
					foreach (var valid in PossiblyBuysFor[giver])
					{
						term += string.Format(" | {0} == \"{1}\"", giver.ToLower(), valid);
					}
					model.AddConstraint("domain_restriction_" + giver, term); 
				}
				model.AddConstraint("one_present_each", Model.AllDifferent(model.Decisions.ToArray()));
				Solution solution = context.Solve(new ConstraintProgrammingDirective());
				
				int i = 0;
				while (solution.Quality != SolverQuality.Infeasible && i < 10)
				{
					Console.WriteLine(i);
					foreach (var d in solution.Decisions)
					{
						Console.WriteLine(string.Format("{0} buys for {1}", d.Name, d.ToString()));
					}
					Console.ReadKey();
					solution.GetNext();
					i++;
				}
				Console.WriteLine("The end");
				Console.ReadKey();
			}
