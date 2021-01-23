    <castle>
        <properties>
            <connectionString>YourConnectionStringHere</connectionString>
        </properties>
        <components>
             <component id="PlcA" service="Namespace.IPlc, AssemblyName" type="Namespace.Plc, AssemblyName">
                 <parameters>
                     <connectionString>${connectionString}</connectionString>
                 </parameters>
             </component>
             <!-- Other IPlc implementations as required -->
             
             <component id="PlcJobWriterA" service="Namespace.IPlcJobWriter, AssemblyName" type="Namespace.PlcJobWriter, AssemblyName">
                  <parameters>
                      <plc>${PlcA}</plc>
                      <commandRegister>
                          <parameters>
                              <address>CommandRegisterAddress</address>
                              <length>CommandRegisterLength</length>
                          <parameters>
                       </commandRegister>
                       <statusRegister>
                          <parameters>
                              <address>StatusRegisterAddress</address>
                              <length>StatusRegisterLength</length>
                          <parameters>
                       </statusRegister>
                  </parameters>
             </component>
             <!-- Other PlcJobWriters as required -->
             <!-- PlcProgramWriter can be configured in the same way -->
             <component id="JobService" service="Namespace.IJobService, AssemblyName" type="Namespace.JobService, AssemblyName">
                 <parameters>
                     <plcJobWriters>
                         <dictionary keyType="System.String" valueType="Namespace.IPlcJobWriter, AssemblyName">
                             <entry key="JobWriterA">${PlcJobWriterA}</entry>
                             <!-- Other entries as required -->
                         </dictionary>
                     </plcJobWriters>  
                 </parameters>
             </component>
             <component id="ProgramService" service="Namespace.IProgramService, AssemblyName" type="Namespace.ProgramService, AssemblyName">
                 <parameters>
                     <plcProgramWriters>
                         <list>
                             <item>${ProgramWriterA}</item>
                             <!-- Other items as required -->
                         </list>
                     </plcProgramWriters>
                 </parameters>
             </component>
        </components>
    </castle>
