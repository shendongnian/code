<span class="nt">&lt;system.web&gt;</span>
  <span class="nt">&lt;httpHandlers&gt;</span>
    <span class="nt">&lt;add</span> <span class="na">path=</span><span class="s">"*"</span> <span class="na">type=</span><span class="s">"ServiceStack.WebHost.Endpoints.ServiceStackHttpHandlerFactory, ServiceStack"</span> <span class="na">verb=</span><span class="s">"*"</span><span class="nt">/&gt;</span>
  <span class="nt">&lt;/httpHandlers&gt;</span>
<span class="nt">&lt;/system.web&gt;</span>
<span class="c">&lt;!-- Required for IIS 7.0 (and above?) --&gt;</span>
<span class="nt">&lt;system.webServer&gt;</span>
  <span class="nt">&lt;validation</span> <span class="na">validateIntegratedModeConfiguration=</span><span class="s">"false"</span> <span class="nt">/&gt;</span>
  <span class="nt">&lt;handlers&gt;</span>
    <span class="nt">&lt;add</span> <span class="na">path=</span><span class="s">"*"</span> <span class="na">name=</span><span class="s">"ServiceStack.Factory"</span> <span class="na">type=</span><span class="s">"ServiceStack.WebHost.Endpoints.ServiceStackHttpHandlerFactory, ServiceStack"</span> <span class="na">verb=</span><span class="s">"*"</span> <span class="na">preCondition=</span><span class="s">"integratedMode"</span> <span class="na">resourceType=</span><span class="s">"Unspecified"</span> <span class="na">allowPathInfo=</span><span class="s">"true"</span> <span class="nt">/&gt;</span>
  <span class="nt">&lt;/handlers&gt;</span>
<span class="nt">&lt;/system.webServer&gt;</span>
