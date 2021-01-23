    modelBuilder.Entity(Of BO.Table.Role)().HasMany(Function(p) p.Permissions).WithMany().
            Map(Sub(m)
                    m.ToTable("RolePermission")
                    m.MapLeftKey("RoleID")
                    m.MapRightKey("PermissionID")
                End Sub)
