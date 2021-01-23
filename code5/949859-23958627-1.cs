    		private Action _methodOnProgress;
			public ChipLoadFirmware(Action method)
			{
				_methodOnProgress = method;
			}
			public bool LoadFirmWare()
			{
				(p) = > 
				{
					_methodOnProgress();
				}
			}
