<PropertyGroup>
		<ContentSQLiteInteropFiles>false</ContentSQLiteInteropFiles>
		<CopySQLiteInteropFiles>false</CopySQLiteInteropFiles>
		<CleanSQLiteInteropFiles>false</CleanSQLiteInteropFiles>
		<CollectSQLiteInteropFiles>false</CollectSQLiteInteropFiles>
</PropertyGroup>
In the csproj of the project that references the nuget package. This part needs to be above the 'Import' of the 'System.Data.SQLite.Core.targets'.
Then, added the following to the csproj-file, so that the x64-version of the 'SQLite.Interop.dll' is placed in the bin folder.
	<ItemGroup>
		<Content Include="..\packages\System.Data.SQLite.Core.1.0.111.0\build\net46\x64\SQLite.Interop.dll">
			<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
		</Content>
	</ItemGroup>
Although this statement needs to be changed when the nuget package is updated.
