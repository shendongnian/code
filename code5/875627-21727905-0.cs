		public static bool IsContainerControl(this Control ctl)
		{
			if (ctl == null)
				return false;
			MethodInfo GetStyle = ctl.GetType().GetMethod("GetStyle", BindingFlags.NonPublic | BindingFlags.Instance);
			if (GetStyle == null)
				return false;
			return (bool)GetStyle.Invoke(ctl, new object[] { ControlStyles.ContainerControl });
		}
