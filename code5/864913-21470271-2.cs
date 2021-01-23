	public class RoleStore : IQueryableRoleStore<Role, int>, IRoleStore<Role, int>, IDisposable {
		private bool Disposed;
		private IDatabaseRepository<Role> RolesRepository { get; set; }
		public RoleStore(
			IDatabaseRepository<Role> rolesRepository) {
			this.RolesRepository = rolesRepository;
		}
		#region IQueryableRoleStore Members
		public IQueryable<Role> Roles {
			get {
				return this.RolesRepository.Set;
			}
		}
		#endregion
		#region IRoleStore Members
		public async Task CreateAsync(
			Role role) {
			this.ThrowIfDisposed();
			if (role == null) {
				throw new ArgumentNullException("role");
			}
			await this.RolesRepository.AddAndCommitAsync(role);
		}
		public async Task DeleteAsync(
			Role role) {
			this.ThrowIfDisposed();
			if (role == null) {
				throw new ArgumentNullException("role");
			}
			await this.RolesRepository.RemoveAndCommitAsync(role);
		}
		public Task<Role> FindByIdAsync(
			int roleId) {
			this.ThrowIfDisposed();
			return Task.FromResult<Role>(this.RolesRepository.FindSingleOrDefault(
				r =>
					(r.Id == roleId)));
		}
		public Task<Role> FindByNameAsync(
			string roleName) {
			this.ThrowIfDisposed();
			return Task.FromResult<Role>(this.RolesRepository.FindSingleOrDefault(
				r =>
					(r.Name == roleName)));
		}
		public async Task UpdateAsync(
			Role role) {
			this.ThrowIfDisposed();
			if (role == null) {
				throw new ArgumentNullException("role");
			}
			await this.RolesRepository.CommitAsync();
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
	}
