    		private FileCodeModel m_FileCodeModel;
		/// <summary>
		/// The FileCodeModel the entity of this property is found in.
		/// </summary>
		public FileCodeModel FileCodeModel
		{
			get
			{
				if (m_FileCodeModel == null)
				{
					m_FileCodeModel = EntityMetadata.FileCodeModel;
				}
				return m_FileCodeModel;
			}
		}
		private Project m_Project;
		/// <summary>
		/// The project this properties entity is contained in.
		/// </summary>
		public Project ContainingProject
		{
			get
			{
				if (m_Project == null)
				{
					m_Project = FileCodeModel.Parent.ContainingProject;
				}
				return m_Project;
			}
		}
		private CodeModel m_CodeModel;
		/// <summary>
		/// The CodeModel for the properties entity.
		/// </summary>
		public CodeModel CodeModel
		{
			get
			{
				if (m_CodeModel == null)
				{
					m_CodeModel = ContainingProject.CodeModel;
				}
				return m_CodeModel;
			}
		}
		/// <summary>
		/// De CodeType van de property
		/// </summary>
		public CodeType CodeType
		{
			get
			{
				if (!m_CodeTypeInitialized)
				{
					if (CodeProperty.IsCodeType)
					{
						CodeTypeRef codeTypeRef = CodeProperty.Type;
						m_CodeType = codeTypeRef.CodeType;
					}
					else
					{
						m_CodeType = CodeModel.CodeTypeFromFullName(CodeProperty.Type.AsFullName);
					}
					m_CodeTypeInitialized = true;
				}
				return m_CodeType;
			}
		}
