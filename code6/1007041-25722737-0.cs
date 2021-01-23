	from
		e in (
			from
				p in Exams
			select  new { 
				o = (p.CreatedDate.Value.Year * 10000 + 
                     p.CreatedDate.Value.Month * 100 +  
                     p.CreatedDate.Value.Day).ToString() + 
                     "-" + p.BPSystolic.ToString() + 
                     "-" + p.BPDiastolic.ToString(), 
				w = p.Worker.Id }
		) group e by e.w into g
	select 
		new {
			n = g.Key,
			m = g.Max(x => x.o)
		}    
