    HRESULT Web2FromSite(IUnknown *punkSite, IWebBrowser2 **pWeb2) {
        IServiceProvider* psp;
        HRESULT hr = punkSite->QueryInterface(IID_IServiceProvider, (void **)&psp);
        if (SUCCEEDED(hr))
        {
            hr = psp->QueryService(SID_SWebBrowserApp, IID_IWebBrowser2, (void **)pWeb2);
            psp->Release();
        }
        return hr;
    }
    HRESULT Doc2FromWeb2(IWebBrowser2 *pWeb2, IHTMLDocument2 **ppDoc2) {
        CComPtr<IDispatch> spDisp;
        HRESULT hr = pWeb2->get_Document(&spDisp);
        if (SUCCEEDED(hr) && spDisp)
        {
            hr = spDisp->QueryInterface(IID_IHTMLDocument2, (void**)ppDoc2);
        } else {
            hr = E_FAIL;
        }
        return hr;
    }
    HRESULT Doc2FromSite(IUnknown *punkSite, IHTMLDocument2 **ppDoc2) {
        CComPtr<IWebBrowser2> spWeb2;
        HRESULT hr = Web2FromSite(punkSite, &spWeb2);
        if (SUCCEEDED(hr)) {
            hr = Doc2FromWeb2(spWeb2, ppDoc2);
        }
        return hr;
    }
