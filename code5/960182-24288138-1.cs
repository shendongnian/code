	model.Users = users
		.Where(u => u.Membership != null)
		.Select(u => new UserBriefModel
				{
					Username = u.UserName,
					Fullname = u.FullName,
					Email = u.Membership.Email,
					Roles = u.UserName.GetRoles()
				}
		})
		.ToList();
