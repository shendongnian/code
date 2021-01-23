    <Extensions>
    <Extension Category="windows.activatableClass.inProcessServer">
      <InProcessServer>
        <Path>Microsoft.Speech.VoiceService.MSSRAudio.dll</Path>
        <ActivatableClass ActivatableClas-sId="Microsoft.Speech.VoiceService.MSSRAudio.Encoder" ThreadingModel="both" />
      </InProcessServer>
    </Extension>
    <Extension Category="windows.activatableClass.proxyStub">
      <ProxyStub ClassId="5807FC3A-A0AB-48B4-BBA1-BA00BE56C3BD">
        <Path>Microsoft.Speech.VoiceService.MSSRAudio.dll</Path>
        <Interface Name="IEncodingSettings" InterfaceId="C97C75EE-A76A-480E-9817-D57D3655231E" />
      </ProxyStub>
    </Extension>
    <Extension Category="windows.activatableClass.proxyStub">
      <ProxyStub ClassId="F1D258E4-9D97-4BA4-AEEA-50A8B74049DF">
        <Path>Microsoft.Speech.VoiceService.Audio.dll</Path>
        <Interface Name="ISpeechVolumeEvent" InterfaceId="946379E8-A397-46B6-B9C4-FBB253EFF6AE" />
        <Interface Name="ISpeechStatusEvent" InterfaceId="FB0767C6-7FAA-4E5E-AC95-A3C0C4D72720" />
      </ProxyStub>
    </Extension>
    </Extensions>
