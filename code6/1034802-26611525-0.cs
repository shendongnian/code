    void OnMouseUp() {
        animator.SetBool("callAnim", false);
        animator.SetBool("callGoAway", true);
        //Removed the assignement of Time.deltaTime as it did nothing for you...
    
        StartCoroutine(DelayedCoroutine());
    }
    IEnumerator DelayedCoroutine()
    {
        yield return new WaitForSeconds(1f); // The parameter is the number of seconds to wait
        target.SendMessage(message, SendMessageOptions.RequireReceiver);
    }
