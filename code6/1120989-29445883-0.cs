	var result = from person in persons
				group person by new { person.Role, person.Company }
				into g 
				select new { Role = g.Key, Company = g.Key.Company, Count = g.Count(item => item.Company == g.Key.Company )};
	var countRole = result.Count(item => item.Role.Role == "Analyst"); // output: 3
	var total = result.Count(); // output: 5
	var countCompany = result.Count(item => item.Company == "IBM"); // output: 2
