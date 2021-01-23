	public class EmployeeStore : IQueryableUserStore<Employee, int>, IUserStore<Employee, int>, IUserPasswordStore<Employee, int>, IUserRoleStore<Employee, int>, IDisposable {
		private bool Disposed;
		private IDatabaseRepository<Role> RolesRepository { get; set; }
		private IDatabaseRepository<Employee> EmployeesRepository { get; set; }
		public EmployeeStore(
			IDatabaseRepository<Role> rolesRepository,
			IDatabaseRepository<Employee> employeesRepository) {
			this.RolesRepository = rolesRepository;
			this.EmployeesRepository = employeesRepository;
		}
		#region IQueryableUserStore Members
		public IQueryable<Employee> Users {
			get {
				return this.EmployeesRepository.Set;
			}
		}
		#endregion
		#region IUserStore Members
		public async Task CreateAsync(
			Employee employee) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			await this.EmployeesRepository.AddAndCommitAsync(employee);
		}
		public async Task DeleteAsync(
			Employee employee) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			await this.EmployeesRepository.RemoveAndCommitAsync(employee);
		}
		public Task<Employee> FindByIdAsync(
			int employeeId) {
			this.ThrowIfDisposed();
			return Task.FromResult<Employee>(this.EmployeesRepository.FindSingleOrDefault(
				u =>
					(u.Id == employeeId)));
		}
		public Task<Employee> FindByNameAsync(
			string userName) {
			this.ThrowIfDisposed();
			return Task.FromResult<Employee>(this.EmployeesRepository.FindSingleOrDefault(
				e =>
					(e.UserName == userName)));
		}
		public async Task UpdateAsync(
			Employee employee) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			await this.EmployeesRepository.CommitAsync();
		}
		#endregion
		#region IDisposable Members
		public void Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected void Dispose(
			bool disposing) {
			this.Disposed = true;
		}
		private void ThrowIfDisposed() {
			if (this.Disposed) {
				throw new ObjectDisposedException(base.GetType().Name);
			}
		}
		#endregion
		#region IUserPasswordStore Members
		public Task<string> GetPasswordHashAsync(
			Employee employee) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			return Task.FromResult<string>(employee.PasswordHash);
		}
		public Task<bool> HasPasswordAsync(
			Employee employee) {
			return Task.FromResult<bool>(!String.IsNullOrEmpty(employee.PasswordHash));
		}
		public Task SetPasswordHashAsync(
			Employee employee,
			string passwordHash) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			employee.PasswordHash = passwordHash;
			return Task.FromResult<int>(0);
		}
		#endregion
		#region IUserRoleStore Members
		public Task AddToRoleAsync(
			Employee employee,
			string roleName) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			if (String.IsNullOrEmpty(roleName)) {
				throw new ArgumentNullException("roleName");
			}
			Role role = this.RolesRepository.FindSingleOrDefault(
				r =>
					(r.Name == roleName));
			if (role == null) {
				throw new InvalidOperationException("Role not found");
			}
			employee.Roles.Add(role);
			return Task.FromResult<int>(0);
		}
		public Task<IList<string>> GetRolesAsync(
			Employee employee) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			return Task.FromResult<IList<string>>(employee.Roles.Select(
				r =>
					r.Name).ToList());
		}
		public Task<bool> IsInRoleAsync(
			Employee employee,
			string roleName) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			if (String.IsNullOrEmpty(roleName)) {
				throw new ArgumentNullException("roleName");
			}
			return Task.FromResult<bool>(employee.Roles.Any(
				r =>
					(r.Name == roleName)));
		}
		public Task RemoveFromRoleAsync(
			Employee employee,
			string roleName) {
			this.ThrowIfDisposed();
			if (employee == null) {
				throw new ArgumentNullException("employee");
			}
			if (String.IsNullOrEmpty(roleName)) {
				throw new ArgumentNullException("roleName");
			}
			Role role = this.RolesRepository.FindSingleOrDefault(
				r =>
					(r.Name == roleName));
			if (role == null) {
				throw new InvalidOperationException("Role is null");
			}
			employee.Roles.Remove(role);
			return Task.FromResult<int>(0);
		}
		#endregion
	}
