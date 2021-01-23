    public class CustomSurrogate : IDataContractSurrogate {
		/// Type.GetType only works for the current assembly or mscorlib.dll
		private static readonly Dictionary<string, Type> AllLoadedTypesByFullName = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Distinct().GroupBy(t => t.FullName).ToDictionary(t => t.Key, t => t.First());
		public static Type GetTypeExt(string typeFullName) {
			return Type.GetType(typeFullName) ?? AllLoadedTypesByFullName[typeFullName];
		}
		private static readonly Dictionary<Type, Translator> Translators;
		static CustomSurrogate() {
			Translators = new Dictionary<Type, Translator> {
				{typeof(LocalDate), new Translator<LocalDate, DateTime>(serialize: d => d.ToDateTime(), deserialize: d => d.ToLocalDate())},
				{typeof(LocalDateTime), new Translator<LocalDateTime, DateTime>(serialize:  d => d.ToDateTimeUnspecified(), deserialize: LocalDateTime.FromDateTime)},
				{typeof(ZonedDateTime), new Translator<ZonedDateTime, string> (serialize: d => d.Serialize(), deserialize: DatesExtensions.DeserializeZonedDateTime)}
			};
		}
		public Type GetDataContractType(Type type) {
			if (Translators.ContainsKey(type)) {
				type = typeof(ReplacementType);
			}
			return type;
		}
		public object GetObjectToSerialize(object obj, Type targetType) {
			Translator translator;
			if (Translators.TryGetValue(obj.GetType(), out translator)) {
				return translator.Serialize(obj);
			}
			return obj;
		}
		public object GetDeserializedObject(object obj, Type targetType) {
			var replacementType = obj as ReplacementType;
			if (replacementType != null) {
				var originalType = GetTypeExt(replacementType.OriginalTypeFullName);
				return Translators[originalType].Deserialize(replacementType.Serialized);
			}
			return obj;
		}
		public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType) {
			throw new NotImplementedException();
		}
		public object GetCustomDataToExport(Type clrType, Type dataContractType) {
			throw new NotImplementedException();
		}
		public void GetKnownCustomDataTypes(Collection<Type> customDataTypes) {
			throw new NotImplementedException();
		}
		public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData) {
			throw new NotImplementedException();
		}
		public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit) {
			throw new NotImplementedException();
		}
	}
