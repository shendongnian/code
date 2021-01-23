    <configuration>
      <system.diagnostics>
        <switches>
          <!--4-verbose.-->
          <add name="SyncTracer" value="4" />
        </switches>
        <trace autoflush="true">
          <listeners>
            <add name="TestListener"
                 type="System.Diagnostics.TextWriterTraceListener"
                 initializeData="c:\MySyncTrace.txt"/>
          </listeners>
        </trace>
      </system.diagnostics>
    </configuration>
