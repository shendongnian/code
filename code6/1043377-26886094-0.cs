    		NewObject balanceInfo = query.AsEnumerable().Select(p => new NewObject
            {
                CostumerName = p.Name,
				CostumerBalance = p.Balance
            });
