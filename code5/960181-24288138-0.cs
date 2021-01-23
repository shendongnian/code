	model.Users = users
		.Where(u => u != null)
		.Select(u => new UserBriefModel
				{
					Username = u.UserName,
					Fullname = u.FullName,
					Email = membershipUser.Email,
					Roles = u.UserName.GetRoles()
				}
		})
		.ToList();
