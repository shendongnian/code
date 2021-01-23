		public class Decision : Entity<Guid>, ICloneable
		{
			public Decision()
			{
				Id = Guid.NewGuid();
				MachineDecisions = new List<MachineDecision>();
			}
			public List<MachineDecision> MachineDecisions { get; set; }
			public object Clone()
			{
				var obj = new Decision();
				if (this.MachineDecisions != null)
				{
					obj.MachineDecisions = MachineDecisions.Select(item =>
					{
						return (MachineDecision)(item as ICloneable).Clone();
					}).ToList();
				}
				return obj;
			}
		}
