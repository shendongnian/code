    <UsingTask
        TaskName="CompareDates"
        TaskFactory="CodeTaskFactory"
        AssemblyFile="$(MSBuildToolsPath)\Microsoft.Build.Tasks.v4.0.dll" >
        <ParameterGroup>
          <FirstDate ParameterType="System.DateTime" Required="true" />
          <SecondDate ParameterType="System.DateTime" Required="true" />
          <Result ParameterType=" "System.Int32" Output="true" />
        </ParameterGroup>
        <Task>
          <Using Namespace="System"/>
          <Code Type="Fragment" Language="cs">
            <![CDATA[
            Log.LogMessage("First Date: " + FirstDate, MessageImportance.High);
            Log.LogMessage("Second Date: " + SecondDate, MessageImportance.High);
            Result = DateTime.Compare(FirstDate, SecondDate);
            ]]>
          </Code>
        </Task>
      </UsingTask>
