		public class _Object
		{
			public Int32 IntField;
			public String StringField;
			public Decimal DecimalField;
			public Guid GuidField;
			private string m_UniqueKey;
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			public string UniqueKey
			{
				get
				{
					if (m_UniqueKey == null)
					{
						m_UniqueKey = IntField.ToString()
									+ "|" + (StringField ?? string.Empty)
									+ "|" + DecimalField.ToString("F6", CultureInfo.InvariantCulture)
									+ "|" + GuidField.ToString("X");
					}
					return m_UniqueKey;
				}
			}
		}
