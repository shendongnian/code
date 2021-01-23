					result = await authContext.AcquireTokenAsync(resource, clientId, uc);
					var principal = await new TokenHelper().GetValidatedClaimsPrincipalAsync(result.AccessToken);
					var claimsIdentity = new ClaimsIdentity(principal.Claims, CookieAuthenticationDefaults.AuthenticationType);
					var properties = new AuthenticationProperties();
					HttpContext.GetOwinContext().Authentication.AuthenticationResponseGrant =
						new AuthenticationResponseGrant(claimsIdentity, properties);
