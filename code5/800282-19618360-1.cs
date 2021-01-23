    DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("Mobile")
			                                          {
				ContextCondition = (ctx =>
				                    ctx.Request.UserAgent.IndexOf("iPad", StringComparison.OrdinalIgnoreCase) >= 0 ||
				                    ctx.Request.UserAgent.IndexOf("iPhone", StringComparison.OrdinalIgnoreCase) >= 0 ||
				                    ctx.Request.UserAgent.IndexOf("Windows Phone", StringComparison.OrdinalIgnoreCase) >= 0 ||
				                    ctx.Request.UserAgent.Contains("Mobile Safari")||
				                    ctx.Request.UserAgent.Contains("Android") &&
				                    ctx.Request.UserAgent.IndexOf("Mobile", StringComparison.OrdinalIgnoreCase) <= 0
				                    )
			});
