		/// <summary>
		/// Tests whether the object is the 'NamedObject'. This is placed into 'DataContext' sometimes by WPF as a dummy.
		/// </summary>
		public static bool IsNamedObject(this object obj)
		{
			return obj.GetType().FullName == "MS.Internal.NamedObject";
		}
