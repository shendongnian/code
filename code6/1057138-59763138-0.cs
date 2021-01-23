				{
					if( param != null )
					{
						//It will check for input and output parameter
						if ( ( param.Direction == ParameterDirection.InputOutput || 
							param.Direction == ParameterDirection.Input ) && 
							(param.Value == null))
						{
							param.Value = DBNull.Value;
						}
						command.Parameters.Add(param);
					}
				}
